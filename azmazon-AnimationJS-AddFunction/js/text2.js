

// var img4=document.queryCommandState('#images a:nth-child(4)');
// var img4=document.getElementById('images').children[4];
// var img4=document.getElementsByClassName('ihddenImg')[3];
// var img4=document.getElementsByName('a')[4];
// console.log(img4);
// img4[0].style.display="block";


var imagesA=document.getElementById('images').children;
// console.log(imagesA);


// imagesA[0].style.display="none";
// imagesA[4].style.display="block";

// imagesA[0].className="hiddenImg";
// imagesA[4].className="displayImg";
var txtboxA=document.querySelectorAll('.txt-box>li');
// console.log(txtboxA);

var currentNo=0;
const nodeLength = 8;
function changeImg(){
    //将图片清除  让图片在if下可以重新循环
    //  for (const item of imagesA) {
        //      item.className="hiddenImg";
        
        //      console.log(item);
        // }
        // var nodeLength=txtboxA.length
        for(var i=0;i<nodeLength;i++){
            imagesA[i].className="hiddenImg";
            txtboxA[i].className="txtItem normalColor"
            //console.log(imagesA[i]);
        }
        
        imagesA[currentNo].className="displayImg";
        txtboxA[currentNo].className="txtItem heighlightColor";
    }
    function leftImg(){
        if (currentNo > 0) { currentNo--; }
        else {
            currentNo = 7;
        } 
    }

    function rightImg() {
        if (currentNo < 7) { currentNo++; }
        else {
            currentNo = 0;
        }  
    }

    
    var timer=window.setInterval(rightImgGo,1000);

    function stopChange()
    {
        window.clearInterval(timer);
    }
    function startChange()
    {
        timer=window.setInterval(rightImgGo,1000);
    }
    var sliderdiv=document.querySelector('.slider');
    // console.log(imagesdiv)
    sliderdiv.addEventListener('mouseover',stopChange);
    sliderdiv.addEventListener('mouseout',startChange);
    
    for(var i=0;i<txtboxA.length;i++){
        txtboxA[i].addEventListener('mouseover',gotoImg)
        txtboxA[i].no=i;
    }
    function gotoImg(){
        // console.log(this.no);
        currentNo=this.no;
        changeImg();
    }
    var leftButton = document.querySelector('.leftButton');
    var rightButton = document.querySelector('.rightButton');

    leftButton.addEventListener('click', leftImgGo);
    rightButton.addEventListener('click', rightImgGo);
    
    // console.log(btnB);
    
    function leftImgGo(){
        leftImg();
        changeImg();
    }
    
    function rightImgGo(){
        rightImg();
        changeImg();
    }
    
    
    