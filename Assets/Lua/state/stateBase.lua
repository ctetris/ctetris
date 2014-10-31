StateBase=class(function(self,itemObjects,name)
        if itemObjects then 
            self.m_itemList = itemObjects 
            table.sort(self.m_itemList,self.sortFn)
        else  
            self.m_itemList={}
        end
        self.name = name or ""
    end)

local StateBase = StateBase

-- function StateBase:getItemCount()
--     local itemList = self.m_itemList
--     local size = 0
--     for k,v in ipairs(itemList) do
--         if v.assets~=nil then size=size+1 end
--     end
--     return size
-- end
function StateBase.sortFn(a,b) 
    return tonumber(a.priority)>tonumber(b.priority) 
end

function StateBase:addItem(obj)
    for i, v in ipairs(self.m_itemList) do
        if v == obj  then
            print("obj is exist in current state ")
           return
        end
    end
    table.insert(self.m_itemList, obj)
    table.sort(self.m_itemList,self.sortFn)
end

function StateBase:removeItem(obj)
    for i, v in ipairs(self.m_itemList) do
        if(v == obj) then
            table.remove(self.m_itemList,i)
            -- print("remove "..tostring(v).." from "..tostring(self))
            if(obj.onRemoveFromState~=nil) then
                obj:onRemoveFromState(self)
            end
        end
    end
end

function StateBase:onFocus(previousState)
    local itemList = self.m_itemList
    for k,v in ipairs(itemList) do
        v:onFocus(previousState)

    end
end

function StateBase:onBlur(newState)
    for k,v in ipairs(self.m_itemList) do
        v:onBlur(newState)
    end
end

function StateBase:clear( ... )
    for k,v in ipairs(self.m_itemList) do
        v:clear()
    end
end

function StateBase:onClick(sender,arg)
    for k,v in ipairs(self.m_itemList) do
        if v.onClick then 
            if v:onClick(sender,arg) then break end
        end
    end
end

function StateBase:onPress(sender,arg)
    for k,v in ipairs(self.m_itemList) do
        if v.onPress then 
            if v:onPress(sender,arg) then break end
        end
    end
end

function StateBase:onDrag(sender,arg)
    for k,v in ipairs(self.m_itemList) do
        if v.onDrag then 
            if v:onDrag(sender,arg) then break end
        end
    end
end

function StateBase:onDrop(sender,arg)
    for k,v in ipairs(self.m_itemList) do
        if v.onDrop then 
            if v:onDrop(sender,arg) then break end
        end
    end
end

function StateBase:onDouble(sender,arg)
    for k,v in ipairs(self.m_itemList) do
        if v.onDouble then 
            if v:onDouble(sender,arg) then break end
        end
    end
end

function StateBase:onCustomer(sender,arg)
    for k,v in ipairs(self.m_itemList) do
        if v.onCustomer then 
            if v:onCustomer(sender,arg) then break end
        end
    end
end

function StateBase:__tostring()
    local str = ""
    for k,v in ipairs(self.m_itemList) do 
        str =str..tostring(v).." " 
    end
    return string.format("StateBase.name = %s ,child = %s ", self.name,str)
end
