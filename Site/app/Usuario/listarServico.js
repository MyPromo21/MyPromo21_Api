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




            idInput.innerHTML = e.id;
            descricaoTd.innerHTML = e.descricao;
            precoTd.innerHTML = e.preco;



            linha.appendChild(idInput);
            linha.appendChild(descricaoTd);
            linha.appendChild(precoTd);




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
(async () => {

    const urlParams = new URLSearchParams(window.location.search);
    let res = await ListarServicos(urlParams.get('id'));
    PreencherTabelaServicos(res, false);

})();


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