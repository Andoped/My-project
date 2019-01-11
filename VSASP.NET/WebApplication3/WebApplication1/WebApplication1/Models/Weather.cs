using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication1.Models
{
    public class Weather
    {
        //"result":{
        //"sk":{
        //	"temp":"6",
        //	"wind_direction":"北风",
        //	"wind_strength":"3级",
        //	"humidity":"99%",
        //	"time":"08:39"
        //},
        //"today":{
        //	"temperature":"8℃~10℃",
        //	"weather":"小雨-中雨转阴",
        //	"weather_id":{
        //		"fa":"21",
        //		"fb":"02"
        //	},
        //	"wind":"北风微风",
        //	"week":"星期五",
        //	"city":"柳州",
        //	"date_y":"2019年01月11日",
        //	"dressing_index":"较冷",
        //	"dressing_advice":"建议着厚外套加毛衣等服装。年老体弱者宜着大衣、呢外套加羊毛衫。",
        //	"uv_index":"最弱",
        //	"comfort_index":"",
        //	"wash_index":"不宜",
        //	"travel_index":"较不宜",
        //	"exercise_index":"较不宜",
        //	"drying_index":""
        //},
        
         [DisplayName("温度")]
        //  result/sk/"humidity":"99%",
        public string Humidity { get; set; }

        [DisplayName("温度")]
        //  result/today/"temperature":"8℃~10℃",
        public string Temperature { get; set; }

        [DisplayName("城市")]
        //  result/today/"city":"柳州",
        public string City { get; set; }

        [DisplayName("风向选择")]
        //	result/sk/"wind_direction":"北风",
        public string Wind_direction { get; set; }

        [DisplayName("星期")]
        //	result/today/"week":"星期五",
        public string Week { get; set; }

        [DisplayName("天气")]
        //	result/today/"dressing_index":"较冷",
        public string Dressing_index { get; set; }

        [DisplayName("建议着")]
        //	result/today/"dressing_advice":"建议着厚外套加毛衣等服装。年老体弱者宜着大衣、呢外套加羊毛衫。",
        public string Dressing_advice { get; set; }

    }
}