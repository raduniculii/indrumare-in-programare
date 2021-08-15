module.exports = (function(){
    let arrLinesRead = [];
    function readAvailableLines(){
      var fs = require('fs');
      var BUFSIZE=256;
      var buf = Buffer.alloc(BUFSIZE);
      var bytesRead;
      var allRead = [];
  
      while (true) { // Loop as long as stdin input is available.
          bytesRead = 0;
          try {
              bytesRead = fs.readSync(process.stdin.fd, buf, 0, BUFSIZE);
          } catch (e) {
              if (e.code === 'EAGAIN') { // 'resource temporarily unavailable'
                  // Happens on OS X 10.8.3 (not Windows 7!), if there's no
                  // stdin input - typically when invoking a script without any
                  // input (for interactive stdin input).
                  // If you were to just continue, you'd create a tight loop.
                  throw 'ERROR: interactive stdin input not supported.';
              } else if (e.code === 'EOF') {
                  // Happens on Windows 7, but not OS X 10.8.3:
                  // simply signals the end of *piped* stdin input.
                  break;          
              }
              throw e; // unexpected exception
          }
          if (bytesRead === 0) {
              // No more stdin input available.
              // OS X 10.8.3: regardless of input method, this is how the end 
              //   of input is signaled.
              // Windows 7: this is how the end of input is signaled for
              //   *interactive* stdin input.
              break;
          }
          let strRead = buf.toString('utf8', 0, bytesRead);
          // Process the chunk read.
          allRead.push(strRead);
          //console.log('Bytes read: %s; content:\n%s', bytesRead, strRead);
          if(process.stdin.isTTY && /\r?\n$/.test(strRead)) break;
      }
      let lines = allRead.join("").split(/\r?\n/);
      if(lines[lines.length - 1] == "") {
          lines.pop();
      }
      return lines;
    }
    return function(){
      if(arrLinesRead.length === 0){
        arrLinesRead = readAvailableLines();
      }
      if(arrLinesRead.length === 0) return "";
  
      return arrLinesRead.splice(0, 1)[0];
    }
})();