

var img4=document.queryCommandState('#images a:nth-child(4)');
var img4=document.getElementById('images').children[4];
var img4=document.getElementsByClassName('ihddenImg')[3];
var img4=document.getElementsByName('a')[4];
// console.log(img4);
// img4[0].style.display="block";


var imagesA=document.getElementById('images').children;
console.log(imagesA);


// imagesA[0].style.display="none";
// imagesA[4].style.display="block";

// imagesA[0].className="hiddenImg";
// imagesA[4].className="displayImg";


var currentNo=0;
function changeImg(){
    //将图片清除  让图片在if下可以重新循环
     for (const item of imagesA) {
         item.className="hiddenImg";
         console.log(item);
    }
    //    for(var i=0;i<imagesA.lengrh;i++){
    //         imagesA[i].className="hiddenImg";
    //         console.log(imagesA[i]);
    //    }

    imagesA[currentNo].className="displayImg";
    if(currentNo<7){currentNo++;}
    else{currentNo=0;}
    //让图片不断循环
}

function stopChange()
{
    window.clearInterval(timer);
}
function startChange()
{
    timer=window.setInterval(changeImg,1000);
}
var imagesdiv=document.getElementById('images');
console.log(imagesdiv)
imagesdiv.addEventListener('mouseover',stopChange);
imagesdiv.addEventListener('mouseout',startChange);

var timer=window.setInterval(changeImg,1000);


