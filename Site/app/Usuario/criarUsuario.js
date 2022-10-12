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

async function SalvarUsuario() {
    let login = document.querySelector('#login').value;
    console.log(login);
    let senha = document.querySelector('#senha').value;
    console.log(senha);
    let nivel = document.querySelector('#nivel').value;
    console.log(nivel);

    let createUsuarioViewModel = {
        Usuario :
        {
            Login : login,
            Senha : senha,
            Nivel : parseInt(nivel)
            
        }        
    };


    console.log(createUsuarioViewModel);

    let response =  EnviarApi(createUsuarioViewModel);
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
    const req =   await fetch('https://localhost:44335/usuario/Create', options)
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