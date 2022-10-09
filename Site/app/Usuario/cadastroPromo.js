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

async function SalvarPromo() {
    let idEndereco = document.querySelector('#idEndereco').value;
    console.log(idEndereco);

    let idEstabelecimento = document.querySelector('#idEstabelecimento').value;
    console.log(idEstabelecimento);

    let token = document.querySelector('#token').value;
    console.log(token);

    let validadePromo = document.querySelector('#validadePromo').value;
    console.log(validadePromo);

    let motivo = document.querySelector('#motivo').value;
    console.log(motivo);
   
    

    let createEstabelecimentoViewModel = {
        Promocao :
        {
            
            Token : token,
            ValidadePromo : validadePromo,
            Motivo : motivo, 
            IdEndereco : parseInt(idEndereco),
            IdEstabelecimento : parseInt(idEstabelecimento),

            
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
    const req =  fetch('https://localhost:44335/promocao/CreatePromocao', options)
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