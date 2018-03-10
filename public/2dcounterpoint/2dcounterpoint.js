
var x, y, sz = 40, mx=0, my=0;
var sel_i=0,sel_j=0;
var oscA,oscB, envA, envB;
function setup() {
    createCanvas(800, 800);
    //noLoop();
    //redraw();
    textSize(20);

    oscA = new p5.Oscillator('sine');
    oscA.amp(0);
    oscA.freq(440); // set frequency
    oscA.start(); // start oscillating
    // Instantiate the envelope
    envA = new p5.Env();
    oscA.amp(envA);
    envA.setADSR(0.1, 0.5, 0.1, 0.5);
    envA.setRange(0.4, 0);


    oscB = new p5.Oscillator('sine');
    oscB.amp(0);
    oscB.freq(440); // set frequency
    oscB.start(); // start oscillating

    envB = new p5.Env();
    oscB.amp(envB);
    envB.setADSR(0.1, 0.5, 0.1, 0.5);
    envB.setRange(0.4, 0);

}

function draw() {

    for (var i = 0; i < 12 * 12; i++) {
        //print("----------");
        curr_i = (i % 12);
        curr_j = (int(i / 12));
        x = sz * curr_i;
        y = sz * curr_j;
        //print(x+ " "+mouseX );
        //print(y+ " "+mouseY );
        
        
        fill(255);
        
        if(x<mouseX && mouseX< x+sz && y<mouseY && mouseY< y+sz){
            fill(0);
            sel_i = curr_i;
            sel_j = curr_j;
        }
        // if(y<mouseY && mouseY< y+sz ){
        //     fill(0);
        // }
        rect(x, y, sz, sz);
        fill(0);
        text(Math.abs(curr_i-curr_j),x+sz/2,y+sz/2);
    }
}

function mousePressed() {
     mx = sz * (mouseX % 12);
     my = sz * (int(mouseY / 12));
    //print("Sound notes "+sel_i + " " + sel_j);
    oscA.freq(midiToFreq(sel_i+12*5));
    //print(midiToFreq(sel_j+12*5));
    oscB.freq(midiToFreq(sel_j+12*5));
    envA.play();
    envB.play();
    //redraw();
}