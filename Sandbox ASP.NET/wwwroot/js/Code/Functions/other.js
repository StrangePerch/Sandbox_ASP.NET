let type = "Sand";

function Save() {
    let to_save = "";
        for (let x = 0; x < width; x++) {
            for (let y = 0; y < height; y++) {
                to_save += world[x][y].constructor.name + ",";
            }
            to_save += ";";
        }
    localStorage.setItem('Level', to_save);
}

function Load() {
    ClearWorld();
    let item = localStorage.getItem('Level');
    if (item != null) {
    let cols = item.split(";");
        for (let x = 0; x < width; x++) {
            let to_load = cols[x].split(",");
            for (let y = 0; y < height; y++) {
                const className = to_load[y];
                world[x][y] = (Function('return new ' + className))();
                Draw(x,y);
            }
        }
    }

}

function Move(x1, y1, x2, y2)
{
    let buffer = world[x2][y2];
    world[x2][y2] = world[x1][y1];
    world[x1][y1] = buffer;
    Draw(x1, y1);
    Draw(x2, y2);
    world[x1][y1].updated = true;
    world[x2][y2].updated = true;
}

function Draw(x, y) {
    context.beginPath();
    context.rect(x * x_mult, y * y_mult, x_mult, y_mult);
    context.fillStyle = world[x][y].color;
    context.fill();
    context.closePath();
}

function SetMaterial(input) {
    type = input;
}

function ParticleFactory() {
    switch (type) {
        case "Sand": return new Sand();
        case "Water": return new Water();
        case "Wood": return new Wood();
        case "Air": return new Air();
        case "Steam": return new Steam();
        case "Fire": return new Fire();
        case "Smoke": return new Smoke();
    }
}