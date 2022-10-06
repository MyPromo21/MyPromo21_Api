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
            let loginTd = document.createElement('td');
            loginTd.classList.add('row-login-usuario');
            let nivelTd = document.createElement('td');
            nivelTd.classList.add('row-nivel-usuario');
            
                        
            idInput.innerHTML = e.id;
            loginTd.innerHTML = e.login;
            nivelTd.innerHTML = e.nivel;
            
    
            linha.appendChild(idInput);
            linha.appendChild(loginTd);
            linha.appendChild(nivelTd);                       
            
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
    const req =  fetch('https://localhost:44335/usuario/ReadAll', options )
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
    const req =  await fetch('https://localhost:44335/usuario/GetUsuario?login='+criterio, options )
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