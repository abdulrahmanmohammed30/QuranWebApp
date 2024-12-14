/** @type {import('tailwindcss').Config} */
module.exports = {
    content: [
        './Pages/**/*.cshtml',
        './Views/**/*.cshtml'
    ],
    theme: {
        extend: {
            cursor: {
                pointer: 'pointer',
            }
        },
    },
    plugins: [],
}

