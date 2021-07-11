let isDrawing = false;
let mouse_x = 0;
let mouse_y = 0;

canvas.addEventListener('mousedown', e => {
    UpdateMousePosition(e);
    isDrawing = true;
});

canvas.addEventListener('mousemove', e => {
    if (isDrawing === true) {
        UpdateMousePosition(e);
    }
});

window.addEventListener('mouseup', e => {
    if (isDrawing === true) {
        UpdateMousePosition(e);
        isDrawing = false;
    }
});

function UpdateMousePosition(e) {
    let rect = canvas.getBoundingClientRect();
    mouse_x = e.clientX - rect.left;
    mouse_y = e.clientY - rect.top;
}

function DrawWithMouse() {
    if(isDrawing) {
        
        let x = Math.floor(mouse_x / x_mult);
        let y = Math.floor(mouse_y / y_mult);
        
        let from;
        let to;
        
        if(size % 2 === 0)
        {
            from = -(size / 2);
            to = size / 2;
        }
        else
        {
            to = Math.floor(size / 2);
            from = -(size - to);
        }
        
        for (let i = from; i < to; i++) {
            for (let j = from; j < to; j++) {
                let pos_x = x + i;
                let pos_y = y + j;
                if(pos_x < 0) break;
                if(pos_y < 0) continue;
                if(pos_x > width - 1) return;
                if(pos_y > height - 1) break;
                if(Math.random() < density / 100)
                    world[pos_x][pos_y] = ParticleFactory();

            }
        }
    }
}
