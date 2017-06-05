
// https://www.keithmcmillen.com/blog/making-music-in-the-browser-web-midi-api/

class Note {
  constructor(midiNote, vel, timeStart) {
    this.midNum = midiNote;
    this.velocity = vel;
    this.timeStamp= timeStart;
  }
}

var midi, data;
var currNote, currVel;
var context = new AudioContext();
var listNotes =[new Note(60,60,0)];

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
    console.log('Success MIDI');
    var inputs = midi.inputs.values();
    // loop over all available inputs and listen for any MIDI input
    for (var input = inputs.next(); input && !input.done; input = inputs.next()) {
        // each time there is a midi message call the onMIDIMessage function
        console.log('Input '+input);
        input.value.onmidimessage = onMIDIMessage;
    }
}

function onMIDIFailure(error) {
    // when we get a failed response, run this code
    console.log("No access to MIDI devices or your browser doesn't support WebMIDI API. Please use WebMIDIAPIShim " + error);
}

function onMIDIMessage(message) {
    data = message.data; // this gives us our [command/channel, note, velocity] data.
    console.log('MIDI data', data, context.currentTime); // MIDI data [144, 63, 73]
    currNote = data[1];
    currVel = data[2];
    listNotes.push( new Note(currNote,currVel,context.currentTime));
}

//==========================================00
// P5

var notePosY=0;
function setup(){
  createCanvas(710, 700);
  // prueba de commit
}

function draw(){
  background(250);
  translate(-context.currentTime, 0);
  for(var i=0; i<listNotes.length;i++ ){
    notePosX= listNotes[i].timeStamp;
    //notePosY= map(listNotes[i].midNum,90,40,100 ,700);
    notePosY=listNotes[i].midNum;
    fill(0);
    ellipse(notePosX,notePosY,10,10);
  }
}