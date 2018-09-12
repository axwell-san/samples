import org.apache.commons.lang3.builder.EqualsBuilder;
import org.apache.commons.lang3.builder.HashCodeBuilder;

import org.openqa.grid.internal.*;
import org.openqa.grid.web.servlet.RegistryBasedServlet;
import org.openqa.grid.web.Hub;
import org.openqa.selenium.remote.*;

import org.json.JSONObject;
import org.json.JSONArray;

import javax.servlet.http.HttpServletRequest;
import javax.servlet.http.HttpServletResponse;

import java.io.IOException;
import java.io.PrintWriter;
import java.util.*;


public class servlet extends RegistryBasedServlet {

    Hub hub;
    HttpServletResponse response;

    public servlet() {
        this(null);
    }

    public servlet(GridRegistry registry) {
        super(registry);
    }

    public void doGet(HttpServletRequest request, HttpServletResponse response) throws IOException {
        hub = getRegistry().getHub();
        this.response = response;

        try {
            doRequest(request);
            } catch (Exception e) {
            response.sendError(HttpServletResponse.SC_INTERNAL_SERVER_ERROR, e.getMessage());
            }
    }

    private void doRequest(HttpServletRequest request) throws Exception {
        String query = request.getQueryString();
        if (query.equals("nodes")){
            doNodesRequest();
        }
        else if(query.equals("hub")){
            doHubRequest();
        }
        else if(query.startsWith("taskkill=")){
            doTaskKillRequest(query.substring("taskkill=".length()));
        }
        else {
            doHelpRequest();
        }
    }

    private void doNodesRequest() throws IOException {
        JSONArray responseObject = new JSONArray();
        for (RemoteProxy proxy : getRegistry().getAllProxies()) {
            JSONObject proxyObject = new JSONObject();
            proxyObject.put("id", proxy.getId());
            proxyObject.put("slotsCount", proxy.getTestSlots().size());
            proxyObject.put("used", proxy.getTotalUsed());
            proxyObject.put("maxNumberOfConcurrentTestSessions", proxy.getMaxNumberOfConcurrentTestSessions());

            Map<Tuple<String, String>, Tuple<Integer, Integer>> browsersPlatformsTotalFree = new HashMap<>();
            for (TestSlot testSlot : proxy.getTestSlots()) {
                Tuple<String, String> testSlotBrowserPlatform = new Tuple<>
                        (String.valueOf(testSlot.getCapabilities().get(CapabilityType.BROWSER_NAME)),
                         String.valueOf(testSlot.getCapabilities().get(CapabilityType.PLATFORM_NAME)));

                if (!browsersPlatformsTotalFree.containsKey(testSlotBrowserPlatform)) {
                    browsersPlatformsTotalFree.put(testSlotBrowserPlatform, new Tuple<>(0, 0));
                }

                browsersPlatformsTotalFree.put(testSlotBrowserPlatform,
                        new Tuple<>(
                                browsersPlatformsTotalFree.get(testSlotBrowserPlatform).x + 1,
                                    testSlot.getSession() == null ? browsersPlatformsTotalFree.get(testSlotBrowserPlatform).y + 1
                                    : browsersPlatformsTotalFree.get(testSlotBrowserPlatform).y));
            }

            JSONArray browsersPlatformsObjects = new JSONArray();
            for (Map.Entry<Tuple<String, String>, Tuple<Integer, Integer>> browserPlatform : browsersPlatformsTotalFree.entrySet())
            {
                JSONObject browserPlatformObject = new JSONObject();
                browserPlatformObject.put("browserName", browserPlatform.getKey().x);
                browserPlatformObject.put("platform", browserPlatform.getKey().y);
                browserPlatformObject.put("total", browserPlatform.getValue().x);
                browserPlatformObject.put("free", browserPlatform.getValue().y);
                browsersPlatformsObjects.put(browserPlatformObject);
            }

            proxyObject.put("browsers", browsersPlatformsObjects);
            responseObject.put(proxyObject);
        }
        respond(responseObject);
    }

    private void doHubRequest() throws IOException {
        JSONObject responseObject = new JSONObject();
        GridRegistry gridRegistry = getRegistry();
        responseObject.put("hubRequestURL", gridRegistry.getHub().getWebDriverHubRequestURL());
        responseObject.put("activeSessionsCount", gridRegistry.getActiveSessions().size());
        responseObject.put("newSessionRequestCount", gridRegistry.getNewSessionRequestCount());
        respond(responseObject);
    }

    private void doTaskKillRequest(String process) throws Exception {
        Runtime.getRuntime().exec("taskkill /F /IM " + process);
    }

    private void doHelpRequest() throws IOException {
        response.setContentType("text/html");
        PrintWriter out = response.getWriter();
        out.println("<h3>" + "query hub|node|taskkill=<process name> - eg. .../grid/admin/servlet?hub" + "</h3>");
    }

    private void respond(JSONObject responseObject) throws IOException {
        response.setContentType("application/json");
        response.setCharacterEncoding("UTF-8");
        response.setStatus(200);
        responseObject.write(response.getWriter());
    }

    private void respond(JSONArray responseObject) throws IOException {
        response.setContentType("application/json");
        response.setCharacterEncoding("UTF-8");
        response.setStatus(200);
        responseObject.write(response.getWriter());
    }

    private class Tuple<X, Y> {

        public final X x;
        public final Y y;

        public Tuple(X x, Y y) {
            this.x = x;
            this.y = y;
        }

        @Override
        public int hashCode() {
            return new HashCodeBuilder(17, 31).
                            append(x).
                            append(y).
                            toHashCode();
        }

        @Override
        public boolean equals(Object obj) {
            if (!(obj instanceof Tuple))
                return false;
            if (obj == this)
                return true;

            Tuple tuple = (Tuple) obj;
            return new EqualsBuilder().
                            append(x, tuple.x).
                            append(y, tuple.y).
                            isEquals();
        }
    }
}