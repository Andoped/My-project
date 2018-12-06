
// var products;
// var take_document=new XMLHttpRequest();
// var location='index.json';
// take_document.open('get',location);
// take_document.responseType='json';

// take_document.onload=function(){
//     if (take_document.status===200) {
//         products=take_document.response
//         console.log(products);
//         initialize();
//     }
//     else
//     {
//         console.log('错误');
//     }
// }
// take_document.send();

// function initialize(){
    
// }
var products;
//这里引用JSON里的数据
console.log(products);
//请求数据
var request = new XMLHttpRequest();
request.open('GET', '../My Files/index.json');
request.responseType = 'json';

request.onload = function() {
  if(request.status === 200) {
    products = request.response;
    initialize();
  } else {
    console.log('Network request for products.json failed with response ' + request.status + ': ' + request.statusText)
  }
};

request.send();

function initialize() {

}