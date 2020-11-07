'use strict';


/**
 * Search text
 * 
 *
 * 注释1
 * 注释换行
 **/
exports.search = function(text) {
  return new Promise(function(resolve, reject) {
    resolve({name: text, id: 1});
  });
}
