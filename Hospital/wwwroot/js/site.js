function GetAll() {
    fetch('https://localhost:7240/api/Hospital/GetAll', {
        'mode': 'cors',
        'headers': {
            'Access-Control-Allow-Origin': '*',
        }
            .then(response => response.json())
            .then(data => console.log(data))  
    });            
};