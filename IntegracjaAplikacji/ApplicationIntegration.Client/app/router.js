import Ember from 'ember';
import config from './config/environment';

var Router = Ember.Router.extend({
  location: config.locationType
});

Router.map(function() {
  this.resource('publishers', { path: '/publishers'}, function () {
      this.resource('publisher.index', {path:'/:publisher_id'});
  });
  this.resource('books', {path: '/books'}, function () {
      this.resource('book.index', {path:'/:book_id'});
  });
  this.route('publisherIndex');
});

export default Router;
