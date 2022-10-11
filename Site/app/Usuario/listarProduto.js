async function PreencherTabelaProdutos(resposta, limpar){
    
    let tabela = document.querySelector('#listagem-usuario');    

    if(limpar)
        tabela.innerHTML = '';

    if(!resposta)
        alert(resposta);
    else if(resposta.length == 0){
        tabela.innerHTML = 'Não há registros para exibir.';
    }
    else {
        resposta.forEach(function(e) {
            let linha = document.createElement('tr');
            
            linha.addEventListener('click', ()=> {            
                window.location.href = "./alterarUsuario.html?id=" + e.id;
            });
            
            
            let idInput = document.createElement('td');
            idInput.classList.add('row-id-usuario');

            let idPromocaoTd = document.createElement('td');
            idPromocaoTd.classList.add('row-idPromocao-usuario');

            let descricaoTd = document.createElement('td');
            descricaoTd.classList.add('row-descricao-usuario');

            let precoTd = document.createElement('td');
            precoTd.classList.add('row-preco-usuario');

            let quantidadeTd = document.createElement('td');
            quantidadeTd.classList.add('row-quantidade-usuario');

            let perecivelTd = document.createElement('td');
            perecivelTd.classList.add('row-perecivel-usuario');

            let validadeProdutoTd = document.createElement('td');
            validadeProdutoTd.classList.add('row-validadeProduto-usuario');

            let linkImagemTd = document.createElement('td');
            linkImagemTd.classList.add('row-linkImagem-usuario');
            
                        
            idInput.innerHTML = e.id;
            idPromocaoTd.innerHTML = e.idPromocao;
            descricaoTd.innerHTML = e.descricao;
            precoTd.innerHTML = e.preco;
            quantidadeTd.innerHTML = e.quantidade;
            perecivelTd.innerHTML = e.perecivel;
            validadeProdutoTd.innerHTML = e.validadeProduto;
            linkImagemTd.innerHTML = e.linkImagem;
            
    
            linha.appendChild(idInput);
            linha.appendChild(idPromocaoTd);
            linha.appendChild(descricaoTd); 
            linha.appendChild(precoTd);
            linha.appendChild(quantidadeTd);
            linha.appendChild(perecivelTd);
            linha.appendChild(validadeProdutoTd);
            linha.appendChild(linkImagemTd);
                                  
            
            tabela.appendChild(linha);

            return linha;         

    
        });
    }
}
async function ListarProdutos(){  
    
    const options = {
        method: 'GET',  
        headers:{'content-type': 'application/json'}                     
    };    
    const req =  fetch('https://localhost:44335/produto/ReadAll', options )
        .then(response => {                
            return response.json();
        })     
        .catch(erro => {
            console.log(erro);
            return erro;
        });
    return req;
}





function Voltar(){
    window.location.href = './index.html';   
}
async function ListarPorCriterio(elemento){
    let texto = elemento.value;
    let resposta = await ListarUsuariosUsandoCriterio(texto);
    PreencherTabelaUsuarios(resposta, true);
}
async function ListarUsuariosUsandoCriterio(criterio){  
    
    const options = {
        method: 'GET',  
        headers:{'content-type': 'application/json'}                     
    };    
    const req =  await fetch('https://localhost:44335/produto/GetUsuario?login='+criterio, options )
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
(async() => {
    let res = await ListarProdutos();
    PreencherTabelaProdutos(res, false);    
})();