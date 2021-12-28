import axios, { Method } from 'axios';
import getView from './ViewRenderer';

export const renderViewFromInput = async (renderToId: string, method: Method, inputId: string, path: string) => {
    document.getElementById(renderToId).innerHTML = "";
    showLoadingSpinner(renderToId);

    const input = (<HTMLInputElement>document.getElementById(inputId));
    const inputValue = input.value;
    const property = input.getAttribute('data-property');

    const body = {
        [property]: inputValue
    }


    try {
        const result = await getView(method, body, path);
        document.getElementById(renderToId).innerHTML = result;
    } catch (e) {
        hideLoadingSpinner();
    }

}

export const renderView = async (renderToId: string, method: Method, body: {}, inputId: string, path: string) => {
    const container = document.getElementById(renderToId);
    container.innerHTML = "";

    showLoadingSpinner(renderToId);

    const input = (<HTMLInputElement>document.getElementById(inputId));
    const inputValue = input.value;
    const property = input.getAttribute('data-property');

    const modifiedBody = { ...body, [property]: inputValue };

    try {
        var result = await getView(method, modifiedBody, path);
        container.innerHTML = result;
    } catch (e) {
        hideLoadingSpinner();
    }

}

export const downloadAudio = async (videoId: string) => {
    const btns = document.getElementsByClassName('download-btn') as HTMLCollectionOf<HTMLButtonElement>;

    const btnsArr = Array.from(btns)

    btnsArr.forEach(btn => {
        btn.disabled = true;
    });

    const link = document.createElement("a");
    link.target = "_blank";
    link.download = `${videoId}.webm`;

    var response = await axios({
        url: `api/download/${videoId}`,
        method: 'POST',
        responseType: 'blob'
    });

    btnsArr.forEach(btn => {
        btn.disabled = false;
    });

    link.href = URL.createObjectURL(
        new Blob([response.data], { type: "audio/webm" })
    );
    link.click();
}

const showLoadingSpinner = (renderToId: string) => {
    const div = document.createElement('div');
    div.id = "loading-spinner"
    div.className = "w-50 d-flex justify-content-center"

    const img = document.createElement('img');
    img.src = "images/loading_spinner.gif";
    img.style.cssText = "object-fit: cover; max-width:100%";

    div.appendChild(img);

    document.getElementById(renderToId).appendChild(div);
}

const hideLoadingSpinner = () => {
    const spinner = document.getElementById('loading-spinner');
    spinner.remove();
}