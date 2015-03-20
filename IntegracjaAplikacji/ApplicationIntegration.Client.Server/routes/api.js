var express = require('express');
var soap = require('soap');
var util = require("util");
var pd = require("pretty-data").pd;
var router = express.Router();
var changeCase = require('change-case');
var soapUrl = 'http://localhost:50685/Services/BookService.svc?singleWsdl';

/* GET users listing. */
router.get('/', function(req, res) {

  res.send('insert here metadata')
});

router.get('/books', function(req, res) { 
  soap.createClient(soapUrl,function(err, client) {  
      client.GetAllBooks( {},function(err, result) {  
          array = result.GetAllBooksResult.BookDto
          array.forEach(function (el) {
            
              
              el["Authors"] = el.Authors.string
           
          });
          res.json(array);
      });
      
  });  
});
router.get('/publishers/:id', function(req, res) { 

  soap.createClient(soapUrl,function(err, client) {  
      client.GetPublisher( {id: req.params.id },function(err, result) {  

        
          res.json(result.GetPublisherResult);
      });
      
  });  
});

module.exports = router;
