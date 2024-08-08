module.exports = {
    content: [
        './Areas/**/*.cshtml',
        './Views/**/*.cshtml',
        './Views/Shared/Components/Paginacion/**/*.cshtml',
        './wwwroot/js/page/*.js',
    ],
    theme: {
        extend: {},
    },
    plugins: [
        require('@tailwindcss/forms')
    ],
}