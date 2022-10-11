async function PreencherTabelaUsuarios(resposta, limpar){
    
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

            let tokenTd = document.createElement('td');
            tokenTd.classList.add('row-token-usuario');

            let validadepromoTd = document.createElement('td');
            validadepromoTd.classList.add('row-validadepromo-usuario');

            let motivoTd = document.createElement('td');
            motivoTd.classList.add('row-motivo-usuario');

            let idEnderecoTd = document.createElement('td');
            idEnderecoTd.classList.add('row-idEndereco-usuario');

            let idEstabelecimentoTd = document.createElement('td');
            idEstabelecimentoTd.classList.add('row-idEstabelecimento-usuario');
            
                        
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
async function ListarUsuarios(){  
    
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
    const req =  await fetch('https://localhost:44335/promocao/GetUsuario?login='+criterio, options )
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
    let res = await ListarUsuarios();
    PreencherTabelaUsuarios(res, false);    
})();