

function setup() {
    createCanvas(800, 800);
    actual = new Notas([0, 4, 7]);
    cir = new Circulo(actual.notas, 200, 200, 300);
    actual.imprimir();
    noLoop();
}

function draw() {
    cir.paint();
}

function keyPressed() {
    switch (key.toLowerCase()) {
        case '`':
            a++;
            break;

        case '1':
            console.log("Transpose");
            actual.transponer12(1);
            break;
        case 'q':
            actual.transponer12(-1);
            break;
        case '2':
            actual.transponer12(2);
            break;
        case 'w':
            actual.transponer12(-2);
            break;

        case 'a':
            console.log("key a press");
            actual.invertir12(0);
            break;
        case 's':
            actual.invertir12(1);
            break;
        case 'd':
            actual.invertir12(2);
            break;
        case 'f':
            actual.invertir12(3);
            break;

        case 'p':
            actual.opP();
            break;
        case 'l':
            actual.opL();
            break;
        case 'r':
            actual.opR();
            break;
    }

    background(255);
    cir.paint();
    redraw();

    console.log(keyCode);
}