// Canvas de CharJS
const cpm = document.getElementById('publicacionesPorMes');
const cpc = document.getElementById('publicacionesCategorias');
const cpa = document.getElementById('publicacionesActivas');
const cpp = document.getElementById('publicacionesPrecios');
const cpt = document.getElementById('publicacionesTop');

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
const url = '/js/reportes/reportesPublicacionesDatosTest.json';
const datos = await fetchDatos(url);

// Graficas
export const renderGraficasPublicaciones = () => {
    new Chart(cpm, {
        type: 'line',
        data: {
            labels: meses,
            datasets: [
                {
                    label: datos[0].publicacionesPorMes[0].anio,
                    data: datos[0].publicacionesPorMes[0].publicaciones,
                    borderColor: "#f97316",
                    backgroundColor: "#fb923c",
                },
                {
                    label: datos[0].publicacionesPorMes[1].anio,
                    data: datos[0].publicacionesPorMes[1].publicaciones,
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
                    labels: {
                        color: '#a1a1aa'
                    }
                },
                title: {
                    display: true,
                    text: 'Cantidad De Publicaciones',
                    color: '#fff'
                }
            },
            scales: {
                x: {
                    ticks: {
                        color: '#a1a1aa'
                    }
                },
                y: {
                    ticks: {
                        color: '#a1a1aa'
                    }
                }
            }
        },
    });


    new Chart(cpc, {
        type: 'polarArea',
        data: {
            labels: datos[1].topCategorias,
            datasets: [
                {
                    data: datos[1].porcentajes,
                    backgroundColor: [
                        "#f59e0b",
                        "#22d3ee",
                        "#6366f1",
                        "#84cc16",
                        "#14b8a6"
                    ],
                    borderColor: "#fff",
                    borderWidth: 1
                }
            ]
        },
        options: {
            responsive: true,
            plugins: {
                legend: {
                    position: 'top',
                    labels: {
                        color: '#a1a1aa'
                    }
                },
                title: {
                    display: true,
                    text: 'Categorías más usadas',
                    color: '#fff'
                }
            },
            scales: {
                r: {
                    ticks: {
                        backdropColor: 'transparent',
                        color: '#fff'
                    },
                    grid: {
                        color: '#a1a1aa'
                    }
                }
            }
        },
    });



    new Chart(cpa, {
        type: 'bar',
        data: {
            labels: datos[2].publicacionesActivasMeses,
            datasets: [
                {
                    label: "Publicaciones Activas",
                    data: datos[2].publicacionesActivas,
                    backgroundColor: "#f97316",
                },
                {
                    label: 'Publicaciones Inactivas',
                    data: datos[2].publicacionesInactivas,
                    backgroundColor: "#22d3ee",
                }
            ]
        },
        options: {
            plugins: {
                title: {
                    display: true,
                    text: 'Publicaciones Activas Vs Inactivas',
                    color: '#fff'
                },
                legend: {
                    labels: {
                        color: '#a1a1aa'
                    }
                }
            },
            responsive: true,
            scales: {
                x: {
                    stacked: true,
                    ticks: {
                        color: '#a1a1aa'
                    }
                },
                y: {
                    stacked: true,
                    ticks: {
                        color: '#a1a1aa'
                    }
                }
            }
        }
    });


    new Chart(cpp, {
        type: 'line',
        data: {
            labels: datos[3].preciosMeses,
            datasets: [
                {
                    label: '$COP',
                    data: datos[3].precios,
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
                    text: 'Promedio de Precios',
                    color: '#fff'
                },
                legend: {
                    labels: {
                        color: '#a1a1aa'
                    }
                }
            },
            scales: {
                x: {
                    ticks: {
                        color: '#a1a1aa'
                    }
                },
                y: {
                    ticks: {
                        color: '#a1a1aa'
                    }
                }
            }
        }
    });

    new Chart(cpt, {
        type: 'bar',
        data: {
            labels: datos[4].tituloPublicaciones,
            datasets: [
                {
                    label: "Top 5",
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
                    labels: {
                        color: '#a1a1aa'
                    }
                },
                title: {
                    display: true,
                    text: 'Publicaciones Mejor Valoradas',
                    color: '#fff'
                }
            },
            scales: {
                x: {
                    ticks: {
                        color: '#a1a1aa'
                    }
                },
                y: {
                    ticks: {
                        color: '#a1a1aa'
                    }
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
