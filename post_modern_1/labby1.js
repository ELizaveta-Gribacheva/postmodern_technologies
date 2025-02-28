function stripedWords(line) {
  let result = 0;
  line = line.toLocaleLowerCase().replace(/[^A-Z/s1-9]/gi, ' ').trim();
  let re = line.replace(/[a,e,i,o,u,y]/g, '?').replace(/[b,c,d,f,g,h,j,k,l,m,n,p,q,r,s,t,v,w,x,z]/g, '*').split(' ');
  result = countValidStripedWords(re);

  return result;
}

function countValidStripedWords(re) {
  let result = 0;

  for(let i = 0; i < re.length; i++) {
    let word = re[i];
    if(word.length === 1 || word.length === 0) {
      continue;
    }
    let check = true;
    for(let j = 0; j < word.length; j++) {
      if(word[j] !== '?' && word[j] !== '*') {
        check = false;
        break;
      }
      if(word[j] === '?' && word[j + 1] === '?') {
        check = false;
        break;
      }
      if(word[j] === '*' && word[j + 1] === '*') {
        check = false;
        break;
      }
    }
    if(check === true) {
      result++;
    }
  }

  return result;
}

module.exports = stripedWords;
console.log(stripedWords('Dog,c?aat,mouse,bird.????????Human.'));
