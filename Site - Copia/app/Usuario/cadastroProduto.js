async function CarregarTemplate(enderecoTela) {
    const template = await fetch(enderecoTela)
        .then(response => {
            return response.text();
        }).catch(erro => {
            console.log(erro);
        });
    return template;
}


function converterParaDomElement(str) {
    let parser = new DOMParser();
    let doc = parser.parseFromString(str, 'text/html');
    return doc.body;
};

async function SalvarProduto() {
    let idPromocao = document.querySelector('#idPromocao').value;
    console.log(idPromocao);
    let descricao = document.querySelector('#descricao').value;
    console.log(descricao);
    let preco = document.querySelector('#preco').value;
    console.log(preco);
    let quantidade = document.querySelector('#quantidade').value;
    console.log(quantidade);
    let perecivel = document.querySelector('#perecivel').value;
    console.log(perecivel);
    let validadeProduto = document.querySelector('#validadeProduto').value;
    console.log(validadeProduto);
    let linkImagem = document.querySelector('#linkImagem').value;
    console.log(linkImagem);
   

    let createEstabelecimentoViewModel = {
        Produto :
        {
            IdPromocao : parseInt(idPromocao),
            Descricao : descricao,
            Preco : parseFloat(preco),
            Quantidade : parseInt(quantidade),
            Perecivel : parseInt(perecivel),
            ValidadeProduto : validadeProduto,
            LinkImagem : linkImagem

        }        
    };


    console.log(createEstabelecimentoViewModel);

    let response =  EnviarApi(createEstabelecimentoViewModel);
    console.log(response);
}

//função para fazer uma request na api;
async function EnviarApi(viewmodel) {

    //opções/dados para fazer a request;
    const options = {
        //método, se é um post, get etc..
        method: 'POST',
        headers: { 'content-type': 'application/json' },
        body: JSON.stringify(viewmodel)
    };

    //TODO: mudar a url para o seu localhost.
    const req =  fetch('https://localhost:44335/produto/CreateProduto', options)
        //caso a request dê certo, retornará a resposta;
        .then(response => {
            response.text()
                .then(data => {
                    alert(data);
                    return data;
                });
        })
        //caso dê erro, irá retornar o erro e mostrar no console
        .catch(erro => {
            console.log(erro);
            return erro;
        });

    return req;
}


function Voltar() {
    window.location = "../../index.html";
}