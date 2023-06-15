document.cookies = {
  set: function (data) {
    document.cookie = data + ";path=/;secure=true;SameSite=Strict";
  },
  get: function () {
    return document.cookie;
  }
}