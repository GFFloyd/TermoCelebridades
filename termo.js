const data = require('./test.json');
const fs = require('node:fs');

let test = {
    "nome": "Brad Pitt",
    "genero": "homem",
    "profissao": "ator",
    "nacionalidade": "estadunidense",
    "idade": 50,
    "altura": 1.75,
    "foto": "",
    "etnia": "branco",
    "premios": [
        "Oscar", "Globo de Ouro", "Palma de Ouro"
    ]
}
let path = "~/termo/test.json"
fs.open(path);
try {
  fs.writeFileSync(path, JSON.stringify(test));
  // file written successfully
} catch (err) {
  console.error(err);
}
fs.close(path);
// console.log(data.map(e => e.nome));
// for (let i = 0; i < data.length; i++) {
//     console.log(data[i].altura);
// }