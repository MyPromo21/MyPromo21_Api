async function PreencherTabelaPromos(resposta, limpar){
    
    let tabela = document.querySelector('#listagem-promocao');    

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
                window.location.href = "./alterarPromocao.html?id=" + e.id;
            });
            
            
            let idInput = document.createElement('td');
            idInput.classList.add('row-id-promocao');

            let tokenTd = document.createElement('td');
            tokenTd.classList.add('row-token-promocao');

            let validadepromoTd = document.createElement('td');
            validadepromoTd.classList.add('row-validadepromo-promocao');

            let motivoTd = document.createElement('td');
            motivoTd.classList.add('row-motivo-promocao');

            let idEnderecoTd = document.createElement('td');
            idEnderecoTd.classList.add('row-idEndereco-promocao');

            let idEstabelecimentoTd = document.createElement('td');
            idEstabelecimentoTd.classList.add('row-idEstabelecimento-promocao');
            
                        
            idInput.innerHTML = e.id;
            tokenTd.innerHTML = e.token;
            validadepromoTd.innerHTML = e.validadepromo;
            motivoTd.innerHTML = e.motivo;
            idEnderecoTd.innerHTML = e.idEndereco;
            idEstabelecimentoTd.innerHTML = e.idEstabelecimento;
    
            linha.appendChild(idInput);
            linha.appendChild(tokenTd);
            linha.appendChild(validadepromoTd);     
            linha.appendChild(motivoTd);
            linha.appendChild(idEnderecoTd);
            linha.appendChild(idEstabelecimentoTd);                    
            
            tabela.appendChild(linha);

            return linha;         

    
        });
    }
}
async function ListarPromos(){  
    
    const options = {
        method: 'GET',  
        headers:{'content-type': 'application/json'}                     
    };    
    const req =  fetch('https://localhost:44335/promocao/ReadAll', options )
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
    const req =  await fetch('https://localhost:44335/promocao/GetPromocaoByID?id='+criterio, options )
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
    let res = await ListarPromos();
    PreencherTabelaPromos(res, false);    
})();