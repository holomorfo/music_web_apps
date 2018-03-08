class Circulo {

    constructor(ac, x, y, dm) {
        this.elAcorde = ac;
        this.px = x;
        this.py = y;
        this.diam = dm;
        this.rad = this.diam / 2;
    }


    paint() {
        ellipseMode(CENTER);
        // Circulo grande
        fill(255);
        ellipse(this.px, this.py, this.diam, this.diam);

        // Circulos pequenios
        //ellipse(this.px, this.py - this.rad, 30, 30);

        var ang = -2 * PI / 12;
        for (var i = 0; i < 12; i++) {
            fill(255);
            for (var j = 0; j < this.elAcorde.length; j++) {
                if (i == this.elAcorde[j]) {
                    fill(0);
                }
            }
            ellipse(this.px + this.rad * cos(i * ang + PI / 2), this.py - this.rad * sin(i * ang + PI / 2), 30, 30);
        }
    }
}

//this.notas

class Notas {
    constructor(notasL) {
        this.notas =notasL;
    }

    pclasses() {
        for (var i = 0; i <this.notas.length; i++) {
           this.notas[i] = this.mod(this.notas[i]);
        }
    }


    opP() {
        if(this.notas.length == 3) {
            this.invertir12(this.notas[0] +this.notas[2]);
        }
    }

    opL() {
        if(this.notas.length == 3) {
            this.invertir12(this.notas[1] +this.notas[2]);
        }
    }

    opR() {
        if(this.notas.length == 3) {
            this.invertir12(this.notas[0] +this.notas[1]);
        }
    }

    invertir12(n) {
        console.log("try invert ");
        for (var i = 0; i <this.notas.length; i++) {
           this.notas[i] = this.mod(-this.notas[i] + n);
        }
    }

    transponer(tras) {
        for (var i = 0; i <this.notas.length; i++) {
           this.notas[i] =this.notas[i] + tras;
        }
    }

    transponer12(tras) {
        for (var i = 0; i <this.notas.length; i++) {
           this.notas[i] = this.mod(this.notas[i] + tras);
        }
    }


    mod(not) {
        var reg = 0;
        if (not >= 0) {
            reg = not % 12;
        }
        else {
            reg = (12 + not % 12) % 12;
        }
        return reg;
    }

    imprimir() {
        console.log("<");
        for (var i = 0; i <this.notas.length; i++) {
            console.log(this.notas[i] + ", ");
        }
        console.log(">");
    }

}
