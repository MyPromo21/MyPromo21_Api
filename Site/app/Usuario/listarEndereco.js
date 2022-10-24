async function PreencherTabelaEnderecos(resposta, limpar){
    
    let tabela = document.querySelector('#listagem-endereco');    

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
                window.location.href = "./visualizarendereco.html?id=" + e.id;
            });
            
            
            let idInput = document.createElement('td');
            idInput.classList.add('row-id-usuario');

            let estadoTd = document.createElement('td');
            estadoTd.classList.add('row-estado-usuario');

            let cidadeTd = document.createElement('td');
            cidadeTd.classList.add('row-cidade-usuario');

            let ruaTd = document.createElement('td');
            ruaTd.classList.add('row-rua-usuario');

            let numeroTd = document.createElement('td');
            numeroTd.classList.add('row-numero-usuario');

            
            
                        
            idInput.innerHTML = e.id;
            estadoTd.innerHTML = e.estado;
            cidadeTd.innerHTML = e.cidade;            
            ruaTd.innerHTML = e.rua;
            numeroTd.innerHTML = e.numero;
            
    
            linha.appendChild(idInput);                 
            linha.appendChild(estadoTd);   
            linha.appendChild(cidadeTd);     
            linha.appendChild(ruaTd);   
            linha.appendChild(numeroTd);   
;                   
            
            tabela.appendChild(linha);

            return linha;         

    
        });
    }
}
async function ListarEnderecos(){  
    
    const options = {
        method: 'GET',  
        headers:{'content-type': 'application/json'}                     
    };    
    const req =  fetch('https://localhost:44335/endereco/ReadAll', options )
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
    const req =  await fetch('https://localhost:44335/endereco/GetUsuario?login='+criterio, options )
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
    let res = await ListarEnderecos();
    PreencherTabelaEnderecos(res, false);    
})();