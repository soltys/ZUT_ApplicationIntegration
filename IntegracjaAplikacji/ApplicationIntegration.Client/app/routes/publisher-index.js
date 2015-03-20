import Ember from 'ember';

export default Ember.Route.extend({
    model: function (publisher_id) {
        this.store.find('publishers', publisher_id);
    }
});
