module.exports = {
    content: [
        './Areas/**/*.cshtml',
        './Views/**/*.cshtml',
        './wwwroot/js/page/*.js',
    ],
    theme: {
        extend: {},
    },
    plugins: [
        require('@tailwindcss/forms')
    ],
}