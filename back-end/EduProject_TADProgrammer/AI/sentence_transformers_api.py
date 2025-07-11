from flask import Flask, request, jsonify
from sentence_transformers import SentenceTransformer, util

app = Flask(__name__)
model = SentenceTransformer('all-MiniLM-L6-v2')

@app.route('/find_similar', methods=['POST'])
def find_similar():
    data = request.get_json()
    query = data.get('query')
    resources = data.get('resources', [])
    
    if not query or not resources:
        return jsonify({"error": "Query and resources are required"}), 400
    
    query_embedding = model.encode(query, convert_to_tensor=True)
    resource_embeddings = model.encode(resources, convert_to_tensor=True)
    
    similarities = util.cos_sim(query_embedding, resource_embeddings)[0]
    top_idx = similarities.argmax().item()
    top_resource = resources[top_idx]
    
    return jsonify({"top_resource": top_resource})

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000)