from flask import Flask, request, jsonify
from flask_cors import CORS
from sentence_transformers import SentenceTransformer, util
import torch

app = Flask(__name__)
CORS(app, resources={r"/*": {"origins": "http://localhost:7047"}})
model = SentenceTransformer('all-MiniLM-L6-v2')

@app.route('/find_similar', methods=['POST'])
def find_similar():
    try:
        data = request.get_json()
        query = data.get('query', '')
        resources = data.get('resources', [])
        print(f"Received query: {query}, resources: {resources}")  # Log input

        if not query or not resources:
            print("Error: Missing query or resources")
            return jsonify({'error': 'Thiếu query hoặc resources'}), 400

        query_embedding = model.encode(query, convert_to_tensor=True)
        resource_embeddings = model.encode(resources, convert_to_tensor=True)
        similarities = util.pytorch_cos_sim(query_embedding, resource_embeddings)[0]
        top_idx = similarities.argmax().item()
        top_resource = resources[top_idx]
        score = float(similarities[top_idx])

        print(f"Returning top_resource: {top_resource}, score: {score}")  # Log output
        return jsonify({
            'top_resource': top_resource,
            'score': score
        })
    except Exception as e:
        print(f"Error: {str(e)}")  # Log errors
        return jsonify({'error': str(e)}), 500

if __name__ == '__main__':
    app.run(host='0.0.0.0', port=5000, debug=True)