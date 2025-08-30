# OpenCrib.Firebase.Backend
Open Crib Backend using Firebase
# 🧩 Project Context
This FireBase backend is still under construction!

# User-related requests:

      GET /users: Get a list of all users.

      GET /users/{id}: Get user details by ID.

      POST /users: Create a new user.

      PUT /users/{id}: Update user details by ID.

      DELETE /users/{id}: Delete a user by ID.


# Post-related requests:

      GET /posts: Get a list of all posts.

      GET /posts/{id}: Get post details by ID.

      POST /posts: Create a new post.

      PUT /posts/{id}: Update post details by ID.

      DELETE /posts/{id}: Delete a post by ID.


# Comment-related requests:

      GET /posts/{postId}/comments: Get comments for a specific post.

      GET /comments/{id}: Get comment details by ID.

      POST /posts/{postId}/comments: Add a new comment to a post.

      PUT /comments/{id}: Update comment details by ID.

      DELETE /comments/{id}: Delete a comment by ID.


# Like-related requests:

      POST /posts/{postId}/likes: Like a post.

      DELETE /posts/{postId}/likes: Remove a like from a post.


# Follow-related requests:

      POST /users/{userId}/follow: Follow a user.

      DELETE /users/{userId}/follow: Unfollow a user.

# Search-related requests:

  GET /users/search: Search for users by name or username.
  GET /posts/search: Search for posts by keyword or hashtag.
