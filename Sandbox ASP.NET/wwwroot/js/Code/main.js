const canvas = document.querySelector('canvas');
const context = canvas.getContext('2d', { alpha: false });

canvas.width = innerWidth * 0.7;
canvas.height = innerHeight * 0.7;

window.onresize = function(event) {
    canvas.width = innerWidth * 0.7;
    canvas.height = innerHeight * 0.7;
    for (let x = 0; x < width; x++) {
        for (let y = height - 1; y >= 0; y--) {
            Draw(x,y);
        }
    }
};

let tick_time = 30;
let ticks_per_second = 1000 / tick_time;

let g = 10 / ticks_per_second;

let y_mult = 4;
let x_mult = 4;

let rect = canvas.getBoundingClientRect();

height = Math.floor(rect.height / y_mult);
width = Math.floor(rect.width / x_mult);

let world = [];

Load();

let interval = setInterval(UpdateWorld, tick_time);
let interval2 = setInterval(DrawWithMouse, tick_time);


