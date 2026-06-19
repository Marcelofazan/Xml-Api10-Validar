## exemploAPIValidarXML
Exemplo de API validando schema em arquivos XML com C# ASP.NET Core 10.

#### 📋 O que voçê vai ver nesse Projeto

| Tecnologia | Descrição |
|-----------|-----------|
| **XSD**  | Arquivo ou documento estruturado que define as regras, a estrutura e os tipos de dados permitidos em um arquivo XML. |
| **XML**  | Linguagem de marcação criada para estruturar, armazenar e transportar dados. |


#### 🔄 Executar da aplicação

- Link Swagger: **http://localhost:5036/swagger/index.html**

#### 🧪 Executar Endpoints 

Executar o Seguinte XML para Validação. 

```bash
<?xml version='1.0' encoding='UTF-8'?>
<pessoa>
    <nome>Silvair</nome>
    <sobrenome>Leite Soares</sobrenome>
    <endereco>
        <logradouro>Rua Goia</logradouro>
        <complemento>Quadra e lote qualquer</complemento>
        <bairro>Setor Gentil Meirelles</bairro>
        <CEP>74575-200</CEP>
    </endereco>
</pessoa>
```