using System;
using System.Linq;
using System.Reflection;
using UnityEngine;

public class DynamicScriptAttacher : MonoBehaviour
{
    // Method to attach a script by class name
    public void AttachScriptByName(GameObject target, string scriptName)
    {
        // Validate the script name
        if (string.IsNullOrEmpty(scriptName))
        {
            Debug.LogError("Script name is null or empty.");
            return;
        }

        // Find the type of the script
        Type scriptType = Assembly.GetExecutingAssembly().GetTypes()
            .FirstOrDefault(t => t.Name == scriptName);

        if (scriptType == null)
        {
            Debug.LogError($"Script '{scriptName}' not found.");
            return;
        }

        // Ensure the script type is a subclass of MonoBehaviour
        if (scriptType.IsSubclassOf(typeof(MonoBehaviour)))
        {
            // Check if the script is already attached
            if (target.GetComponent(scriptType) == null)
            {
                // Add the script to the GameObject
                target.AddComponent(scriptType);
                Debug.Log($"Script '{scriptName}' successfully attached to {target.name}.");
            }
            else
            {
                Debug.LogWarning($"Script '{scriptName}' is already attached to {target.name}.");
            }
        }
        else
        {
            Debug.LogError($"The type '{scriptName}' is not a MonoBehaviour script.");
        }
    }
}