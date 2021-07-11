// noinspection JSSuspiciousNameCombination
class Water {
    color = "#2254ff";
    updated = false;
    solidity = 5;
    velocity = {x: 0, y: 0};

    constructor() {
        switch (Math.round(Math.random() * 3)) {
            case 0: this.color = "#0000ff";
                break;
            case 1: this.color = "#0000e6";
                break;
            case 2: this.color = "#0032ff";
                break;
            case 3: this.color = "#0032e6";
                break;
        }
    }
    
    Update(x, y) {
        if (this.updated === true){
            return;
        }

        //Stable
        if (y === height - 1) return;
        if (world[x][y + 1].solidity < this.solidity) {
            Move(x, y, x, ++y);
        } else if (
            x > 0
            && world[x - 1][y + 1].solidity < this.solidity) {
            Move(x, y, --x, ++y);
        } else if (
            x < width - 1
            && world[x + 1][y + 1].solidity < this.solidity) {
            Move(x, y, ++x, ++y);
        } else if (
            x > 0
            && world[x - 1][y].solidity < this.solidity) {
            Move(x, y, --x, y);
        } else if (
            x < width - 1
            && world[x + 1][y].solidity < this.solidity) {
            Move(x, y, ++x, y);
        }

        // TODO: Better water physics
        //
        //     this.velocity.y += g;
        //
        //     let i = 0;
        //     while(i < this.velocity.y)
        //     {
        //         if(y + i + 1 > height - 1 || world[x][y + i + 1].solidity >= this.solidity)
        //             break;
        //         i++;
        //     }
        //
        //     Move(x,y,x,y + i);
        //
        //     y += i;
        //
        //     let down = y === height - 1 || world[x][y + 1].solidity >= this.solidity;
        //     let left = x === 0 || world[x - 1][y].solidity >= this.solidity;
        //     let right = x === width - 1 || world[x + 1][y].solidity >= this.solidity;
        //
        //
        //     if(down) {
        //         if (left && !right) {
        //             this.velocity.x = this.velocity.y;
        //         } else if (right && !left) {
        //             this.velocity.x = -this.velocity.y;
        //         } else if (
        //             y === height - 1
        //             || (x > 0 && world[x - 1][y + 1].solidity > this.solidity
        //             && x < width - 1 && world[x + 1][y + 1].solidity > this.solidity)
        //         ) {
        //             if (Math.random() < 0.5)
        //                 this.velocity.x = this.velocity.y;
        //             else
        //                 this.velocity.x = -this.velocity.y;
        //         }
        //         this.velocity.y = 0;
        //     }
        //
        //     i = 0;
        //
        //     while(i < this.velocity.x)
        //     {
        //         if(x + i + 1 > width - 1 || world[x + i + 1][y].solidity >= this.solidity)
        //             break;
        //         i++;
        //     }
        //
        //     Move(x,y,x + i,y);
        //
        //     x += i;
        //     i = 0;
        //     while(i > this.velocity.x)
        //     {
        //         if(x + i - 1 < 0 || world[x + i - 1][y].solidity >= this.solidity)
        //             break;
        //         i--;
        //     }
        //     Move(x,y,x + i,y);
        //
        //     x += i;
        //
        
    }
}
