
// https://www.keithmcmillen.com/blog/making-music-in-the-browser-web-midi-api/
console.log('Testing');
class Note {
    constructor(midiNote, vel, timeStart) {
        this.midNum = midiNote;
        this.velocity = vel;
        this.timeStamp = timeStart;
        this.isClosed = false;
    }

    setEndTime(endTm) {
        this.endTime = endTm - this.timeStamp;
        this.isClosed = true;
    }

}

var midi, data;
var currNote, currVel;
var context = new AudioContext();
var listNotes = [];
var sustainPressef = false;
// request MIDI access
if (navigator.requestMIDIAccess) {
    navigator.requestMIDIAccess({
        sysex: false
    }).then(onMIDISuccess, onMIDIFailure);
} else {
    alert("No MIDI support in your browser.");
}

// midi functions
function onMIDISuccess(midiAccess) {
    // when we get a succesful response, run this code
    midi = midiAccess; // this is our raw MIDI data, inputs, outputs, and sysex status
    console.log('Success MIDI __');
    var inputs = midi.inputs.values();
    // loop over all available inputs and listen for any MIDI input
    for (var input = inputs.next(); input && !input.done; input = inputs.next()) {
        // each time there is a midi message call the onMIDIMessage function
        console.log('Input ' + input);
        input.value.onmidimessage = onMIDIMessage;
    }
}

function onMIDIFailure(error) {
    // when we get a failed response, run this code
    console.log("No access to MIDI devices or your browser doesn't support WebMIDI API. Please use WebMIDIAPIShim " + error);
}

function midiOffMessage(listNotes, number) {
    for (var i = 0; i < listNotes.length; i++) {
        if (!listNotes[i].isClosed && listNotes[i].midNum == number) {
            //console.log('close note');
            listNotes[i].setEndTime(context.currentTime);
        }
    }
}

function midiOnMessage(listNotes, note, vel) {
    if (listNotes.length > 50) {
        listNotes.shift();
    }
    listNotes.push(new Note(note, vel, context.currentTime));
}

function onMIDIMessage(message) {
    //console.log('test');
    data = message.data; // this gives us our [command/channel, note, velocity] data.
    if (128 <= data[0] && data[0] < 144) {
        console.log('MIDI Note Off', data, context.currentTime); // MIDI data [144, 63, 73]
        // Run list, remove elements    
        //if (sustainPressef) {
        midiOffMessage(listNotes, data[1])
        //}
    } else if (144 <= data[0] && data[0] < 160) {
        console.log('MIDI Note On', data, context.currentTime); // MIDI data [144, 63, 73]
        currNote = data[1];
        currVel = data[2];
        midiOnMessage(listNotes, currNote, currVel);
    } else if (data[0] == 176) {
        console.log('MIDI Note soft pedal', data, context.currentTime); // MIDI data [144, 63, 73]
        // if (data[2] > 0) {
        //     sustainPressef = false;
        //     for (var i = 0; i < listNotes.length; i++) {
        //         //console.log('close note');
        //         listNotes[i].setEndTime(context.currentTime);
        //     }
        // } else {
        //     sustainPressef = true;

        // }
    }

    // prueba
    //console.log("num list "+listNotes.length);
    //console.log('MIDI data', data, context.currentTime); // MIDI data [144, 63, 73]
}

//==========================================00
// P5

var notePosY = 0;
var w = window.innerWidth * 0.95;
var h = window.innerHeight * 0.95;
var scaledTime = 0;
var secsWindow = 5;
var offsetX = w * 0.85;
var osc, env;

function setup() {
    createCanvas(w, h);
    colorMode(HSB, 50);
    console.log('ahi te va');

    osc = new p5.Oscillator('sine');
    osc.amp(0); // set amplitude
    osc.freq(440); // set frequency
    osc.start(); // start oscillating

    // Instantiate the envelope
    env = new p5.Env();
    osc.amp(env);
    // set attackTime, decayTime, sustainRatio, releaseTime
    env.setADSR(0.001, 0.5, 0.1, 0.5);

    // set attackLevel, releaseLevel
    env.setRange(1, 0);

}

function draw() {
    background(200);
    scaledTime = context.currentTime;
    scaledTime = map(context.currentTime, 0, secsWindow, 0, w)
    translate(-scaledTime, 0);
    //scale(10,1);
    for (var i = 0; i < listNotes.length; i++) {
        //notePosX= listNotes[i].timeStamp+w/2;
        notePosX = map(listNotes[i].timeStamp, 0, secsWindow, 0, w) + offsetX;
        if (listNotes[i].isClosed) {
            noteWidthX = map(listNotes[i].endTime, 0, secsWindow, 0, w);
        } else {
            //console.log('not closed');
            tempWidth = context.currentTime - listNotes[i].timeStamp
            noteWidthX = map(tempWidth, 0, secsWindow, 0, w);
        }
        notePosY = map(listNotes[i].midNum, 30, 95, h - 50, 50);
        //notePosY=listNotes[i].midNum;
        rectMode(CORNER);
        noteSizeY = map(listNotes[i].velocity, 0, 100, 0, 20);
        colorMap = map(listNotes[i].velocity, 0, 100, 0, 50);
        fill(colorMap, 50, 50);
        rect(notePosX, notePosY, noteWidthX, -noteSizeY);
        textSize(22);
        fill(0, 50, 0);
        text("" + int(listNotes[i].velocity), notePosX, notePosY - 50)
    }
}

function keyPressed() {
    //    osc.freq(freq);
    var note = keyToFreq();
    var vol = map(mouseY, 0, height, 127, 0);
    console.log("Freq " + note);
    midiOnMessage(listNotes, note, vol);
    osc.freq(midiToFreq(note));
    //env.play(osc);
    env.triggerAttack();
  
    //env.play(osc);
    //    env.triggerAttack();
}

function keyReleased() {

    midiOffMessage(listNotes, keyToFreq())
    env.triggerRelease();
}

function keyToFreq() {
    freq = 0;
    switch (key) {
        case 'Q':
            freq = midiToFreq(60);
            break;
        case '2':
            freq = midiToFreq(61);
            break;
        case 'W':
            freq = midiToFreq(62);
            break;
        case '3':
            freq = midiToFreq(63);
            break;
        case 'E':
            freq = midiToFreq(64);
            break;
        case 'R':
            freq = midiToFreq(65);
            break;
        case '5':
            freq = midiToFreq(66);
            break;
        case 'T':
            freq = midiToFreq(67);
            break;
        case '6':
            freq = midiToFreq(68);
            break;
        case 'Y':
            freq = midiToFreq(69);
            break;
        case '7':
            freq = midiToFreq(70);
            break;
        case 'U':
            freq = midiToFreq(71);
            break;
    }
    return freqToMidi(freq);
}

//  midiOffMessage(listNotes,data[1])
