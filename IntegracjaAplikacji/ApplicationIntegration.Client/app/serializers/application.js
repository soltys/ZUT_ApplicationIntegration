import DS from 'ember-data';

export default DS.RESTSerializer.extend({
    extract: function(store, primaryType, payload, id, requestType) {
        var i, record, payloadWithRoot;
        // if the payload has a length property, then we know it's an array
        if (payload.length) {
            for (i = 0; i < payload.length; i++) {
                record = payload[i];
                this.mapRecord(record);
            }
        } else {
            // payload is a single object instead of an array
            this.mapRecord(payload);
        }
        payloadWithRoot = {};
        payloadWithRoot[primaryType.typeKey] = payload;
        return this._super(store, primaryType, payloadWithRoot, id, requestType);
    },

    mapRecord: function(record) {
        var propertyName, value, newPropertyName;

        for (propertyName in record) {
            value = record[propertyName];
            newPropertyName = propertyName.camelize();
            record[newPropertyName] = value;
            delete record[propertyName];
        }
    },
    serializeIntoHash: function(hash, type, record) {
        var jsonRecord, propertyName, value;
        jsonRecord = record.toJSON();
        for (propertyName in jsonRecord) {
            value = jsonRecord[propertyName];
            hash[propertyName.capitalize()] = value;
        }
    }
});
