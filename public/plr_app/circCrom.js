
var oscA, oscB, oscC, envA, envB, envC;
function setup() {
    createCanvas(800, 800);
    actual = new Notas([0, 4, 7]);
    cir = new Circulo(actual.notas, 200, 200, 300);
    actual.imprimir();
    noLoop();

    oscA = new p5.Oscillator('sine');
    oscA.amp(0);
    oscA.freq(440); // set frequency
    oscA.start(); // start oscillating
    // Instantiate the envelope
    envA = new p5.Env();
    oscA.amp(envA);
    envA.setADSR(0.1, 0.5, 0.1, 0.5);
    envA.setRange(0.3, 0);


    oscB = new p5.Oscillator('sine');
    oscB.amp(0);
    oscB.freq(440); // set frequency
    oscB.start(); // start oscillating

    envB = new p5.Env();
    oscB.amp(envB);
    envB.setADSR(0.1, 0.5, 0.1, 0.5);
    envB.setRange(0.3, 0);

    oscC = new p5.Oscillator('sine');
    oscC.amp(0);
    oscC.freq(440); // set frequency
    oscC.start(); // start oscillating

    envC = new p5.Env();
    oscC.amp(envC);
    envC.setADSR(0.1, 0.5, 0.1, 0.5);
    envC.setRange(0.3, 0);

}

function draw() {
    cir.paint();
}

function keyPressed() {
    print(key);
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

    oscA.freq(midiToFreq(actual.notas[0] + 12 * 5));
    oscB.freq(midiToFreq(actual.notas[1] + 12 * 5));
    oscC.freq(midiToFreq(actual.notas[2] + 12 * 5));
    envA.play();
    envB.play();
    envC.play();

    background(255);
    cir.paint();
    redraw();

    console.log(keyCode);

    // VexFlow
    VF = Vex.Flow;

    const staff = document.getElementById('boo');
    while (staff.hasChildNodes()) {
        staff.removeChild(staff.lastChild);
    }

    // Create an SVG renderer and attach it to the DIV element named "boo".
    var vf = new VF.Factory({ renderer: { elementId: 'boo' } });
    var score = vf.EasyScore();
    var system = vf.System();

    system.addStave({
        voices: [score.voice(score.notes('(' + midToName(actual.notas[0]) + '4 '+midToName(actual.notas[1]) + '4 ' + midToName(actual.notas[2]) + '4)/q, A4/r, A4/r, A4/r'))]
    }).addClef('treble').addTimeSignature('4/4');

    vf.draw();

}

function midToName(number) {
    var val = "c";
    switch (number) {
        case 0:
            val = "c";
            break;
        case 1:
            val = "c#";
            break;
        case 2:
            val = "d";
            break;
        case 3:
            val = "e#";
            break;
        case 4:
            val = "E";
            break;
        case 5:
            val = "f";
            break;
        case 6:
            val = "f#";
            break;
        case 7:
            val = "g";
            break;
        case 8:
            val = "g#";
            break;
        case 9:
            val = "a";
            break;
        case 10:
            val = "a#";
            break;
        case 11:
            val = "b";
            break;
    }
    return val;
}
