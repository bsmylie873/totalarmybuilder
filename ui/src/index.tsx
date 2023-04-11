import ReactDOM from "react-dom/client";
import { BrowserRouter as Router } from "react-router-dom";
import App from "./App";
import { AuthContext } from "./contexts";
import { Toaster } from "react-hot-toast";
const root = ReactDOM.createRoot(
  document.getElementById("root") as HTMLElement
);
root.render(
  <Router>
    <Toaster />
    <AuthContext.AuthProvider>
      <App />
    </AuthContext.AuthProvider>
  </Router>
);
