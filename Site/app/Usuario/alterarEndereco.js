async function getPessoaId() {
    const urlParams = new URLSearchParams(window.location.search);
    let res = await BuscarPorId(urlParams.get('id'));
    PreencherFormulario(res);
}
async function Remover() {

    let id = document.querySelector('#id-pessoa').value;

    const options = {
        method: 'DELETE',
        headers: { 'content-type': 'application/json' }
    };
    const req = await fetch('https://localhost:44335/pessoa/remover?id=' + id, options)
        .then(response => {
            return response.json();
        })
        .catch(erro => {
            console.log(erro);
            return erro;
        });
    if (req.sucesso) {
        alert(req.mensagem);
        Voltar();
    }
    else {
        alert(req.mensagem);
    }
}
async function BuscarPorId(id) {
    const options = {
        method: 'GET',
        headers: { 'content-type': 'application/json' }
    };
    const req = await fetch('https://localhost:44335/endereco/GetEnderecoByID?id=' + id, options)
        .then(response => {
            return response.json();
        })
        .catch(erro => {
            console.log(erro);
            return erro;
        });
    return req;
}


async function PreencherFormulario(json) {



    let dadosForm = document.querySelector("#form");

    let idEstabelecimento = dadosForm.querySelector("#idEstabelecimento");
    let estado = dadosForm.querySelector("#estado");
    let cidade = dadosForm.querySelector("#cidade");
    let bairro = dadosForm.querySelector("#bairro");
    let rua = dadosForm.querySelector("#rua");
    let numero = dadosForm.querySelector("#numero");
    let complemento = dadosForm.querySelector("#complemento");
    let cep = dadosForm.querySelector("#cep");

    idEstabelecimento.value = json.id;
    estado.value = json.estado;
    cidade.value = json.cidade;
    bairro.value = json.bairro;
    rua.value = json.rua;
    numero.value = json.numero;
    complemento.value = json.complemento;
    cep.value = json.cep;
}


async function EnviarApi(viewmodel) {

    const options = {
        method: 'PUT',
        headers: { 'content-type': 'application/json' },
        body: JSON.stringify(viewmodel)
    };

    //TODO: mudar a url para o seu localhost.
    const req = await fetch('https://localhost:44335/usuario/alterar', options)
        //caso a request dê certo, retornará a resposta;
        .then(response => {
            response.text()
                .then(data => {
                    return data;
                });
        })
        .catch(erro => {
            console.log(erro);
            return erro;
        });

    return req;
}
async function Atualizar() {

    let id = parseInt(document.querySelector('#id-usuario').value);
    console.log(id);
    let login = document.querySelector('#login').value;
    console.log(login);


    let usuarioDto = {
        id,
        login,
    };

    let atualizarPessoaViewModel = {
        usuarioDto
    };

    const options = {
        method: 'PUT',
        headers: { 'content-type': 'application/json' },
        body: JSON.stringify(atualizarPessoaViewModel)
    };

    //TODO: mudar a url para o seu localhost.
    const req = await fetch('https://localhost:44335/usuario/Update', options)
        //caso a request dê certo, retornará a resposta;
        .then(response => {
            return response.json();
        })
        .catch(erro => {
            console.log(erro);
            return erro;
        });

    if (req.sucesso) {
        alert(req.mensagem);
        Voltar();
    }
    else {
        alert(req.mensagem);
    }

}
function Voltar() {
    window.location.href = './index.html';
}
function convertToDate(data) {
    var pattern = /^(\d{1,2})\/(\d{1,2})\/(\d{4})$/;
    var arrayDate = data.match(pattern);
    var dt = new Date(arrayDate[3], arrayDate[2] - 1, arrayDate[1]);
    return dt;
}

getPessoaId();