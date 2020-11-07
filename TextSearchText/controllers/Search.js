'use strict';

var utils = require('../utils/writer.js');
var Search = require('../service/SearchService');

module.exports.search = function search (req, res, next) {
  var text = req.swagger.params['text'].value;
  Search.search(text)
    .then(function (response) {
      utils.writeJson(res, response);
    })
    .catch(function (response) {
      utils.writeJson(res, response);
    });
};
