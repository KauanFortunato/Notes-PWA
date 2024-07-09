function search(id) {
    let input = document.getElementById(id).value;
    input = input.toLowerCase();
    let elements = document.getElementsByClassName('card-title');
    let noteCard = document.getElementsByClassName('note-card');

    for (i = 0; i < elements.length; i++) {
        if (!elements[i].innerHTML.toLowerCase().includes(input)) {
            noteCard[i].style.display = "none";
        } else {
            noteCard[i].style.display = "block";
        }
    }
}

function searchWorkspace(id) {
    let input = document.getElementById(id).value;
    input = input.toLowerCase();
    let elements = document.getElementsByClassName('nav-link');
    let noteCard = document.getElementsByClassName('workspace-info-container');

    for (i = 0; i < elements.length; i++) {
        if (!elements[i].innerHTML.toLowerCase().includes(input)) {
            noteCard[i].style.display = "none";
        } else {
            noteCard[i].style.display = "flex";
        }
    }
}


function removeDate() {
    let dateCreate = document.getElementsByClassName('date-create');

    for (i = 0; i < dateCreate.length; i++) {
        dateCreate[i].style.display = "none";
    }
}

function addDate() {
    let dateCreate = document.getElementsByClassName('date-create');

    for (i = 0; i < dateCreate.length; i++) {
        dateCreate[i].style.display = "block";
    }
}