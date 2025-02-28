
module.exports = [
    {
      ignores: ["node_modules/"],
      languageOptions: {
        ecmaVersion: "latest",
        sourceType: "module",
        globals: {
          window: "readonly", 
        },
      },
      rules: {
        indent: ["error", 2],
        quotes: ["error", "single"],
        semi: ["error", "always"],
      },
    },
  ];
  