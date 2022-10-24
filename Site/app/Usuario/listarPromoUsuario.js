async function PreencherTabelaPromos(resposta, limpar) {

    let tabela = document.querySelector('#listagem-promocao');

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

            linha.addEventListener('click', () => {
                window.location.href = "./visualizarPromocao.html?id=" + e.id;
            });


            let idInput = document.createElement('td');
            idInput.classList.add('row-id-promocao');

            let tokenTd = document.createElement('td');
            tokenTd.classList.add('row-token-promocao');

            let motivoTd = document.createElement('td');
            motivoTd.classList.add('row-motivo-promocao');

            let descontoTd = document.createElement('td');
            descontoTd.classList.add('row-desconto-promocao');





            idInput.innerHTML = e.id;
            tokenTd.innerHTML = e.token;

            motivoTd.innerHTML = e.motivo;

            descontoTd.innerHTML = e.desconto;

            linha.appendChild(idInput);
            linha.appendChild(tokenTd);

            linha.appendChild(motivoTd);

            linha.appendChild(descontoTd);


            tabela.appendChild(linha);

            return linha;


        });
    }
}
async function ListarPromos(valorDesconto) {

    const options = {
        method: 'GET',
        headers: { 'content-type': 'application/json' }
    };
    const req = await fetch('https://localhost:44335/promocao/CarregarInicio?Desconto=' + valorDesconto, options)
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
    const req = await fetch('https://localhost:44335/promocao/GetPromocaoByID?id=' + criterio, options)
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
    let res = await ListarPromos(urlParams.get('valorDesconto'));
    PreencherTabelaPromos(res, false);
})();


