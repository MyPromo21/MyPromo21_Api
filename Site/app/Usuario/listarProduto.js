async function PreencherTabelaProdutos(resposta, limpar) {

    let tabela = document.querySelector('#listagem-produto');

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
                window.location.href = "./alterarUsuario.html?id=" + e.id;
            });


            let idInput = document.createElement('td');
            idInput.classList.add('row-id-produto');

            let descricaoTd = document.createElement('td');
            descricaoTd.classList.add('row-descricao-produto');

            let precoTd = document.createElement('td');
            precoTd.classList.add('row-preco-produto');

            let quantidadeTd = document.createElement('td');
            quantidadeTd.classList.add('row-quantidade-produto');




            // inputremoverproduto.addEventListener('click', () => {
            //     window.location.href = "./alterarUsuario.html?id=" + e.id;
            // });





            idInput.innerHTML = e.id;
            descricaoTd.innerHTML = e.descricao;
            precoTd.innerHTML = e.preco;
            quantidadeTd.innerHTML = e.quantidade;



            linha.appendChild(idInput);
            linha.appendChild(descricaoTd);
            linha.appendChild(precoTd);
            linha.appendChild(quantidadeTd);



            tabela.appendChild(linha);

            return linha;


        });
    }
}

async function PreencherTabelaSomaValor(soma, limpar) {

    let tabela = document.querySelector('#listagem-somavalor');

    if (limpar)
        tabela.innerHTML = '';

    if (!soma)
        alert(soma);
    else if (soma.length == 0) {
        tabela.innerHTML = 'Não há registros para exibir.';
    }
    else {
        soma.forEach(function (e) {
            let linha = document.createElement('tr');

            let somaValorInput = document.createElement('td');
            somaValorInput.classList.add('row-somaValor-produto');


            somaValorInput.innerHTML = e.somaValor;




            linha.appendChild(somaValorInput);

            tabela.appendChild(linha);

            return linha;


        });
    }
}

async function ListarProdutos(id) {

    const options = {
        method: 'GET',
        headers: { 'content-type': 'application/json' }
    };
    const req = await fetch('https://localhost:44335/produto/ListaDeProdutoPorId?id=' + id, options)
        .then(response => {
            return response.json();
        })
        .catch(erro => {
            console.log(erro);
            return erro;
        });
    return req;
}

async function SomarValorProdutos(id) {

    const options = {
        method: 'GET',
        headers: { 'content-type': 'application/json' }
    };
    const req = await fetch('https://localhost:44335/produto/SomaDeProdutos?id=' + id, options)
        .then(response => {
            return response.json();
        })
        .catch(erro => {
            console.log(erro);
            return erro;
        });
    return req;
}



async function RemoverProduto(id) {

    const options = {
        method: 'DELETE',
        headers: { 'content-type': 'application/json' }
    };
    const req = await fetch('https://localhost:44335/produto/DeleteProduto?id=' + id, options)
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
    const req = await fetch('https://localhost:44335/produto/GetUsuario?login=' + criterio, options)
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
    let res = await ListarProdutos(urlParams.get('id'));    
    PreencherTabelaProdutos(res, false);


    // let soma = await SomarValorProdutos(urlParams.get('id'));
    // PreencherTabelaSomaValor(soma, false);

})();