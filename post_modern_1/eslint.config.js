// eslint.config.js (CommonJS, будет работать без "type": "module")
module.exports = [
    {
      ignores: ["node_modules/"], // Игнорируем node_modules
      languageOptions: {
        ecmaVersion: "latest",
        sourceType: "module",
        globals: {
          window: "readonly", // Вместо env.browser
        },
      },
      rules: {
        indent: ["error", 2],
        quotes: ["error", "single"],
        semi: ["error", "always"],
      },
    },
  ];
  