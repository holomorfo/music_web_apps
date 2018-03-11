listChordTypes = {
    "listTypes": [
        { "name": "M", "notes": [0, 4, 7] },
        { "name": "m", "notes": [0, 3, 7] },
        { "name": "o", "notes": [0, 3, 6] },
        { "name": "+", "notes": [0, 4, 8] },
        { "name": "M7", "notes": [0, 4, 7, 11] },
        { "name": "D7", "notes": [0, 4, 7, 10] },
        { "name": "m7", "notes": [0, 3, 7, 10] },
        { "name": "o/7", "notes": [0, 3, 6, 10] },
        { "name": "o7", "notes": [0, 3, 6, 9] },
        { "name": "mM7", "notes": [0, 3, 7, 11] },
        { "name": "D7*5", "notes": [0, 4, 10] },
        { "name": "DM9*5", "notes": [0, 2, 4, 10] },
        { "name": "Dm9*5", "notes": [0, 1, 4, 10] },


        { "name": "5", "notes": [0, 7] },
        { "name": "Sus4", "notes": [0, 5, 7] },
        { "name": "Sus2", "notes": [0, 2, 7] },
        //{ "name": "6", "notes": [0,4,7,9] }, Se confunde con A7 en  "notes": [CM}
        //{ "name": "m6", "notes": [0,3,7,9] },
        { "name": "9", "notes": [0, 2, 4, 7, 10] },
        { "name": "m9", "notes": [0, 2, 3, 7, 10] },
        { "name": "M9", "notes": [0, 2, 4, 7, 11] },
        { "name": "mM9", "notes": [0, 2, 3, 7, 11] },
        { "name": "11", "notes": [0, 2, 4, 5, 7, 10] },
        { "name": "m11", "notes": [0, 2, 3, 5, 7, 10] },
        { "name": "M11", "notes": [0, 2, 4, 5, 7, 11] },
        { "name": "mM11", "notes": [0, 2, 3, 5, 7, 11] },
        { "name": "13", "notes": [0, 2, 4, 7, 9, 10] },
        { "name": "m13", "notes": [0, 2, 3, 7, 9, 10] },
        { "name": "M13", "notes": [0, 2, 4, 7, 9, 11] },
        { "name": "mM13", "notes": [0, 2, 3, 7, 9, 11] },
        { "name": "Add9", "notes": [0, 2, 4, 7] },
        { "name": "MAdd9", "notes": [0, 2, 3, 7] },
        { "name": "6Add9", "notes": [0, 2, 4, 7, 9] },
        { "name": "m6Add9", "notes": [0, 2, 3, 7, 9] },
        { "name": "D7Add11", "notes": [0, 4, 5, 7, 10] },
        { "name": "M7Add11", "notes": [0, 4, 5, 7, 11] },
        { "name": "m7Add11", "notes": [0, 3, 5, 7, 10] },
        { "name": "mM7Add11", "notes": [0, 3, 5, 7, 11] },
        { "name": "D7Add13", "notes": [0, 4, 7, 9, 11] },
        { "name": "M7Add13", "notes": [0, 4, 7, 9, 11] },
        { "name": "m7Add13", "notes": [0, 3, 7, 9, 10] },
        { "name": "mM7Add13", "notes": [0, 3, 7, 9, 11] },
        { "name": "7b5", "notes": [0, 4, 6, 10] },
        { "name": "7#5", "notes": [0, 4, 8, 10] },
        { "name": "7b9", "notes": [0, 1, 4, 7, 10] },
        { "name": "7#9", "notes": [0, 3, 4, 7, 10] },
        { "name": "7#5b9", "notes": [0, 1, 4, 8, 10] },
        { "name": "m7#5", "notes": [0, 3, 8, 10] },
        { "name": "m7b9", "notes": [0, 1, 3, 7, 10] },
        { "name": "9#11", "notes": [0, 2, 4, 6, 7, 11] },
        { "name": "9b13", "notes": [0, 2, 4, 7, 8, 11] },
        { "name": "6sus4", "notes": [0, 5, 7, 9] },

        { "name": "7sus4", "notes": [0, 5, 7, 10] },
        { "name": "M7sus4", "notes": [0, 5, 7, 11] },
        { "name": "9sus4", "notes": [0, 2, 5, 7, 10] },
        { "name": "M9sus4", "notes": [0, 2, 5, 7, 11] },

        { "name": "2m", "notes": [0, 1] },
        { "name": "2M", "notes": [0, 2] },
        { "name": "3m", "notes": [0, 3] },
        { "name": "3M", "notes": [0, 4] },
        { "name": "4P", "notes": [0, 5] },
        { "name": "6+", "notes": [0, 6] },
        { "name": "5P", "notes": [0, 7] },
        { "name": "6m", "notes": [0, 8] },
        { "name": "6M", "notes": [0, 9] },
        { "name": "7m", "notes": [0, 10] },
        { "name": "7M", "notes": [0, 11] }
    ]
}

function checkIfEqual(arr1, arr2) {
    if (arr1.length != arr2.length) {
        return false;
    }
    //sort them first, then join them and just compare the strings
    return arr1.sort().join() == arr2.sort().join();
}


function getChordByParam(searchVal, searchField = "name") {
    var results = [];
    listChordTypes.listTypes.map(function (elem) {
        if (searchField == "name") {
            if (elem[searchField] == searchVal) {
                results.push(elem);
            }
        } else if (searchField == "notes") {
            if (checkIfEqual(elem[searchField], searchVal)) {
                results.push(elem);
            }
        }
    });
    return results;
}

function createChordArray(bass, kind) {
    var notesList = getChordByParam(kind, "name")[0].notes;
    return notesList.map(x => (x + bass) % 12);
}

/*
Harmony

Uses ES6
*/

class Chord {

    constructor(notesList = []) {
        if (notesList.length > 0) {
            this.notesList = notesList;
            this.notesList.sort();

            this.simplify();
            this.checkType();
            // this.asignarIndiceLista();
            // this.setTipoVoces();
            // this.setInversion();
            // this.setInversionString();
        }
    }

    simplify() {
        // Create a temporary copy
        var notesTemp = this.notesList.slice();
        notesTemp = this.notesList.map(x => x % 12);
        this.notasSimplificadas = Array.from(new Set(notesTemp));
    }

    checkType() {
        this.chordTypeArray =  getChordByParam( this.notasSimplificadas, "notes")[0].notes;
        this.chordType = getChordByParam( this.notasSimplificadas, "notes")[0].name;
        this.fundamental12 = this.chordTypeArray[0];
    }

    checkFundamental(){

    }

}




/*************************************
            TESTS
*************************************/
// console.log(getChordByParam( "D7"));
// console.log(getChordByParam( [0, 3, 6,9], "notes"));

//console.log(createChordArray(9, "m"));
 var arm = new Chord([8,5,1]);
 console.log(arm.notesList);
 console.log(arm.chordType);
 console.log(arm.fundamental12);


