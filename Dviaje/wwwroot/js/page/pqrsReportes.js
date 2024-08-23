// Canvas de CharJS
const cpm = document.getElementById('pqrsPorMes');
const cpc = document.getElementById('categoriasPqrs');
const cpa = document.getElementById('pqrsActivas');
const cpp = document.getElementById('tiempoResolucion');
const cpt = document.getElementById('pqrsTop');

// Utilidad meses
const meses = ["Enero", "Febrero", "Marzo", "Abril", "Mayo", "Junio", "Julio", "Agosto", "Septiembre", "Octubre", "Noviembre", "Diciembre"];

// Datos del API
async function fetchDatos(url) {
    try {
        const response = await fetch(url);
        if (!response.ok) {
            throw new Error(`Error: ${response.status}`);
        }
        return await response.json();
    } catch (error) {
        console.error("Error al leer los datos:", error);
        return null;
    }
}

// Obtencion de Datos
const url = '/js/page/resportesPqrsTest.json';
const datos = await fetchDatos(url);

if (datos) {
    // Graficas
    new Chart(cpm, {
        type: 'line',
        data: {
            labels: meses.slice(0, datos[0].pqrsPorMes[0].pqrs.length),
            datasets: [
                {
                    label: datos[0].pqrsPorMes[0].anio,
                    data: datos[0].pqrsPorMes[0].pqrs,
                    borderColor: "#f97316",
                    backgroundColor: "#fb923c",
                },
                {
                    label: datos[0].pqrsPorMes[1].anio,
                    data: datos[0].pqrsPorMes[1].pqrs,
                    borderColor: "#06b6d4",
                    backgroundColor: "#67e8f9",
                }
            ]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top',
                },
                title: {
                    display: true,
                    text: 'Cantidad De PQRS'
                }
            }
        },
    });

    new Chart(cpc, {
        type: 'polarArea',
        data: {
            labels: datos[1].topCategoriasPQRS,
            datasets: [
                {
                    data: datos[1].porcentajes,
                    backgroundColor: [
                        "#f59e0b",
                        "#22d3ee",
                        "#6366f1",
                        "#84cc16",
                        "#14b8a6"
                    ]
                }
            ]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top',
                },
                title: {
                    display: true,
                    text: 'Categorías más comunes de PQRS'
                }
            }
        },
    });

    new Chart(cpa, {
        type: 'bar',
        data: {
            labels: datos[2].pqrsActivasMeses,
            datasets: [
                {
                    label: "PQRS Activas",
                    data: datos[2].pqrsActivas,
                    backgroundColor: "#f97316",
                },
                {
                    label: 'PQRS Cerradas',
                    data: datos[2].pqrsCerradas,
                    backgroundColor: "#22d3ee",
                }
            ]
        },
        options: {
            plugins: {
                title: {
                    display: true,
                    text: 'PQRS Activas Vs Cerradas'
                },
            },
            responsive: true,
            scales: {
                x: {
                    stacked: true,
                },
                y: {
                    stacked: true
                }
            }
        }
    });

    new Chart(cpp, {
        type: 'line',
        data: {
            labels: datos[3].tiempoResolucionMeses,
            datasets: [
                {
                    label: 'Horas Promedio',
                    data: datos[3].tiempoResolucionPromedio,
                    borderColor: "#f97316",
                    backgroundColor: "#fb923c50",
                    pointStyle: 'circle',
                    pointRadius: 10,
                    pointHoverRadius: 15
                }
            ]
        },
        options: {
            responsive: true,
            plugins: {
                title: {
                    display: true,
                    text: 'Tiempo Promedio de Resolución (en horas)'
                }
            }
        }
    });

    new Chart(cpt, {
        type: 'bar',
        data: {
            labels: datos[4].tituloPQRS,
            datasets: [
                {
                    label: "Top 5 PQRS",
                    data: datos[4].notas,
                    backgroundColor: [
                        "#f59e0b",
                        "#22d3ee",
                        "#6366f1",
                        "#84cc16",
                        "#14b8a6"
                    ]
                }
            ]
        },
        options: {
            indexAxis: 'y',
            elements: {
                bar: {
                    borderWidth: 2,
                }
            },
            responsive: true,
            plugins: {
                legend: {
                    position: 'right',
                },
                title: {
                    display: true,
                    text: 'Mejor Valoración de PQRS'
                }
            },
            onClick: (event, elements) => {
                if (elements.length > 0) {
                    const index = elements[0].index;
                    window.open(datos[4].links[index], '_blank');
                }
            }
        },
    });
}
