import FileSaver from 'file-saver';

export function export2Json(data: string) {
  const blob = new Blob([data], { type: 'text/plain;charset=utf-8' });
  FileSaver.saveAs(blob, `naiveemr_${Date.now()}.json`);
}

export function readAsStringFromJsonFile(fileInput: any, callback: Function) {
  if (fileInput.files && fileInput.files.length > 0 && fileInput.files[0].size > 0) {
    const file = fileInput.files[0];
    console.log('aaaaaa');

    if (window.FileReader) {
      const reader = new FileReader();
      reader.onloadend = function (evt) {
        if (evt.target && evt.target.readyState == 2) {
          callback(evt.target.result);
        }
      };
      reader.readAsText(file);
    }
  }
}
