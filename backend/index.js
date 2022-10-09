const express = require('express')
const app = express()
const port = 5000

app.get('/', (req, res) => {
  res.send('Hello World!')
})

app.get('/api/mensagem', (req, res) => {
    res.send({ express: 'Hello From Express' });
  });

app.listen(port, () => {
  console.log(`API ativa e ecutando na porta ${port}`)
})