async function PreencherTabelaServicos(resposta, limpar) {

    let tabela = document.querySelector('#listagem-servico');

    if (limpar)
        tabela.innerHTML = '';

    if (!resposta)
        alert(resposta);
    else if (resposta.length == 0) {
        tabela.innerHTML = 'Não há registros para exibir.';
    }
    else {
        resposta.forEach(function (e) {
            let linha = document.createElement('tr');

            


            let idInput = document.createElement('td');
            idInput.classList.add('row-id-servico');

            let descricaoTd = document.createElement('td');
            descricaoTd.classList.add('row-descricao-servico');

            let precoTd = document.createElement('td');
            precoTd.classList.add('row-preco-servico');

            let inputremoverservico = document.createElement('input');
            let divremoverservico = document.createElement('div');
            divremoverservico.classList.add("form-outline");
            divremoverservico.classList.add("form-white");
            divremoverservico.classList.add("mb-4");
            inputremoverservico.type = "button";
            inputremoverservico.classList.add("form-control");
            inputremoverservico.classList.add("btn");
            inputremoverservico.classList.add("btn-primary");
            inputremoverservico.value = "Remover";

            divremoverservico.appendChild(inputremoverservico);




            idInput.innerHTML = e.id;
            descricaoTd.innerHTML = e.descricao;
            precoTd.innerHTML = e.preco;



            linha.appendChild(idInput);
            linha.appendChild(descricaoTd);
            linha.appendChild(precoTd);

            linha.appendChild(divremoverservico);

            divremoverservico.addEventListener('click', () => {
                RemoverServico(e.id);
            });



            tabela.appendChild(linha);

            return linha;


        });
    }
}
async function ListarServicos(id) {

    const options = {
        method: 'GET',
        headers: { 'content-type': 'application/json' }
    };
    const req = await fetch('https://localhost:44335/servico/ListaDeServicoPorId?id=' + id, options)
        .then(response => {
            return response.json();
        })
        .catch(erro => {
            console.log(erro);
            return erro;
        });
    return req;
}





function Voltar() {
    window.location.href = './index.html';
}
async function ListarPorCriterio(elemento) {
    let texto = elemento.value;
    let resposta = await ListarUsuariosUsandoCriterio(texto);
    PreencherTabelaUsuarios(resposta, true);
}
async function ListarUsuariosUsandoCriterio(criterio) {

    const options = {
        method: 'GET',
        headers: { 'content-type': 'application/json' }
    };
    const req = await fetch('https://localhost:44335/servico/GetUsuario?login=' + criterio, options)
        .then(response => {
            return response.json();
        })
        .catch(erro => {
            console.log(erro);
            return erro;
        });
    return req;
}
//inicia a listagem.



async function RemoverServico(id) {

    const options = {
        method: 'DELETE',
        headers: { 'content-type': 'application/json' }
    };
    const req = await fetch('https://localhost:44335/servico/DeleteServico?id=' + id, options)
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
        document.location.reload(true);
    }
    
}


(async () => {

    const urlParams = new URLSearchParams(window.location.search);
    let res = await ListarServicos(urlParams.get('id'));
    PreencherTabelaServicos(res, false);

})();